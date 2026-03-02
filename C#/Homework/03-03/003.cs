public class HW
{
    public int size;
    public int[] arr = new int[size];
    public HW(int s)
    {
        size = s;
    }

    public compress()
    {
        int no_zero_index = 0;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] != 0) no_zero_index = i;
        
        
    }
}



