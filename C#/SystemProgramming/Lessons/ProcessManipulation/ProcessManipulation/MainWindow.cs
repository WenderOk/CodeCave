using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;

namespace ProcessManipulation
{
    public partial class MainWindow : Form
    {
        const uint WM_SETTEXT = 0x0C; // вид сообщения
        // импорт функции WinAPI для отсылки сообщения окну с дескриптором hWnd
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg,
            int wParam, string lParam);
        // список дочерних процессов
        List<Process> Processes = new List<Process>();
        int Counter = 0; // счетчик дочерних процессов

        public MainWindow()
        {
            InitializeComponent();
            LoadAvailableAssemblies(); // загрузка доступных сборок
        }

        // метод, загружающий доступные сборки решения
        // (запускается из конструктора объекта класса)
        void LoadAvailableAssemblies()
        {
            // получить название текущей сборки, чтобы исключить
            // ее попадание в список доступных сборок
            string except = new FileInfo(Application.ExecutablePath).Name;
            except = except.Substring(0, except.IndexOf(".")); // без расширения
            // получить все исполняемые файлы из домашней директории
            string[] files = Directory.GetFiles(Application.StartupPath, "*.exe");
            foreach (var file in files)
            {
                // получить имя файла
                string fileName = new FileInfo(file).Name;
                // если имя файла не имя сборки проекта, добавить в список
                if (fileName.IndexOf(except) == -1)
                    lbAvailable.Items.Add(fileName);
            }
        }

        // метод, получающий PID родительского процесса (использует WMI)
        // (требует подключения пространства имен System.Management)
        // (требует установки пакета System.Management с помощью NuGet)
        // (работает только в Windows)
        // (запускается из метода RunProcess)
        int GetParentProcessId(int Id)
        {
            int parentId = 0;
            using (ManagementObject obj = new ManagementObject(
                "win32_process.handle=" + Id.ToString()))
            {
                obj.Get();
                parentId = Convert.ToInt32(obj["ParentProcessId"]);
            }
            return parentId;
        }

        // метод для отправки сообщения WM_SETTEXT
        void SetChildWindowText(IntPtr Handle, string text)
        {
            SendMessage(Handle, WM_SETTEXT, 0, text);
        }

        // обработчик события Exited объекта класса Process
        // (используется в методе RunProcess)
        void proc_Exited(object sender, EventArgs e)
        {
            // убрать процесс из списка запущенных, добавить в список доступных
            Process proc = sender as Process;
            lbRunning.Items.Remove(proc.ProcessName);
            lbAvailable.Items.Add(proc.ProcessName);
            // убрать процесс из списка дочерних процессов
            Processes.Remove(proc);
            Counter--;
            // поменять текст для окон всех дочерних процессов
            int index = 0;
            foreach (var p in Processes)
                SetChildWindowText(p.MainWindowHandle,
                                   "Child process № " + ++index);
        }

        // метод, запускающий процесс с заданным именем сборки
        // (запускается из обработчика нажатия на кнопку Start)
        void RunProcess(string AssamblyName)
        {
            // запустить процесс, добавить в список, выдать окошко с сообщением
            Process proc = Process.Start(AssamblyName);
            Processes.Add(proc);
            if (Process.GetCurrentProcess().Id == GetParentProcessId(proc.Id))
                MessageBox.Show(proc.ProcessName +
                    " действительно дочерний процесс текущего процесса!");
            // настроить запущенный процесс
            proc.EnableRaisingEvents = true; // должен генерировать события
            proc.Exited += proc_Exited;      // добавить обработчик при выходе
            SetChildWindowText(proc.MainWindowHandle,
                               "Child process № " + (++Counter));
            // добавить процесс в список запущенных, если его там еще нет,
            // убрать из списка доступных
            if (!lbRunning.Items.Contains(proc.ProcessName))
                lbRunning.Items.Add(proc.ProcessName);
            lbAvailable.Items.Remove(lbAvailable.SelectedItem);
        }

        // объявление делегата
        // (используется в методе ExecuteOnProcessesByName)
        delegate void ProcessDelegate(Process proc);

        // метод, выполняющий заданную функцию для дочерних процессов
        // с заданным именем
        // (запускается из обработчиков нажатия кнопок Stop, CloseWindow и Refresh)
        void ExecuteOnProcessesByName(string ProcessName, ProcessDelegate func)
        {
            // получаем список процессов с заданным именем и перебираем их
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (var process in processes)
                // если это дочерний процесс для нашего,
                // запустить заданную функцию
                if (Process.GetCurrentProcess().Id == GetParentProcessId(process.Id))
                    func(process);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RunProcess(lbAvailable.SelectedItem.ToString());
        }

        // (используется в обработчике нажатия кнопки Stop)
        void Kill(Process proc)
        {
            proc.Kill();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(lbRunning.SelectedItem.ToString(),
                                     Kill);
            lbRunning.Items.Remove(lbRunning.SelectedItem);
        }

        // (используется в обработчике нажатия кнопки CloseWindow)
        void CloseMainWindow(Process proc)
        {
            proc.CloseMainWindow();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(lbRunning.SelectedItem.ToString(),
                                     CloseMainWindow);
            lbRunning.Items.Remove(lbRunning.SelectedItem);
        }

        // (используется в обработчике нажатия кнопки Refresh)
        void Refresh_func(Process proc)
        {
            proc.Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(lbRunning.SelectedItem.ToString(),
                                     Refresh_func);
        }

        private void btnNotepad_Click(object sender, EventArgs e)
        {
            RunProcess("notepad.exe");
        }

        private void lbAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAvailable.SelectedItems.Count == 0)
                btnStart.Enabled = false;
            else
                btnStart.Enabled = true;
        }

        private void lbRunning_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRunning.SelectedItems.Count == 0)
            {
                btnStop.Enabled = false;
                btnClose.Enabled = false;
                btnRefresh.Enabled = false;
            }
            else
            {
                btnStop.Enabled = true;
                btnClose.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var proc in Processes)
                proc.Kill();
        }
    }
}
