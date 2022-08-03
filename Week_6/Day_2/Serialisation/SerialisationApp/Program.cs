namespace SerialisationApp
{
    internal class Program
    {
        //private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");
        private static ISerialise? _serialiser;
        static void Main(string[] args)
        {
            Trainee trainee = new Trainee
            {
                FirstName = "Dylan",
                LastName = "Cole",
                SpartaNo = 100
            };

            _serialiser = new SerialiserBinary();
            _serialiser.SerialiseToFile($"{_path}/BinaryTrainee.bin", trainee);
            Trainee deserialisedDylan = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/BinaryTrainee.bin");

            //if (trainee == deserialisedDylan)
            //{
            //    Console.WriteLine("Welcome back");
            //}
            //else
            //{
            //    Console.WriteLine("Imposter!!!");
            //}

            _serialiser = new SerialiserXML();
            //Write our trainee to file
            _serialiser.SerialiseToFile($"{_path}/XMLTrainee.xml", trainee);
            Trainee deserialisedDylanXML = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/XMLTrainee.xml");

            var eng120 = new Course();
            eng120.AddTrainee(trainee);
            eng120.AddTrainee(new Trainee { FirstName = "Tom", LastName = "Wolstencroft", SpartaNo = 101 });
            _serialiser.SerialiseToFile($"{_path}/XMLCourse.xml", eng120);
            Thread.Sleep(5000);
            var editedCourse = _serialiser.DeserialiseFromFile<Course>($"{_path}/XMLCourseEdited.xml");

            _serialiser = new SerialiserJson();
            _serialiser.SerialiseToFile($"{_path}/JsonTrainee.json", trainee);
            var desJTrainee = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/JsonTrainee.json");

            _serialiser.SerialiseToFile($"{_path}/Course.json", eng120);
            var desJCourse = _serialiser.DeserialiseFromFile<Course>($"{_path}/Course.json");

        }
    }
}