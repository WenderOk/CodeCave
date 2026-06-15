using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CW_15_06.Model
{
    public class Manager
    {
        public Observation CurrentObservation {  get; private set; }
        private ObservableCollection<Classification> classifications = new ObservableCollection<Classification>();
        public ObservableCollection<Classification> Classifications => classifications;

        private ObservableCollection<Observation> observations = new ObservableCollection<Observation>();
        public ObservableCollection<Observation> Observations => observations;

        private ObservableCollection<ObservationObject> objects = new ObservableCollection<ObservationObject>();
        public ObservableCollection<ObservationObject> Objects => objects; 
        public Manager() { }

        public void SaveToXml_objects(string path, ObservableCollection<ObservationObject> collection)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<ObservationObject>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            { serializer.Serialize(fs, collection); }
        }

        public void AddObject(ObservationObject newObject)
        {
            objects.Add(newObject);
        }

        public void AddClassification(Classification newClassification)
        {
            classifications.Add(newClassification);
        }

    }
}
