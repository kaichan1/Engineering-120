namespace SerialisationApp
{
    internal class Program
    {
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

            var s1 = SerialiserFactory.MakeSerialiser("binary");
            s1.SerialiseToFile($"{_path}/BinaryTrainee.bin", trainee);
            Trainee deserialisedDylan = s1.DeserialiseFromFile<Trainee>($"{_path}/BinaryTrainee.bin");


            var s2 = SerialiserFactory.MakeSerialiser("XML");
            s2.SerialiseToFile($"{_path}/XMLTrainee.xml", trainee);
            Trainee deserialisedDylanXML = s2.DeserialiseFromFile<Trainee>($"{_path}/XMLTrainee.xml");

            var eng120 = new Course();
            eng120.AddTrainee(trainee);
            eng120.AddTrainee(new Trainee { FirstName = "Tom", LastName = "Wolstencroft", SpartaNo = 101 });
            s2.SerialiseToFile($"{_path}/XMLCourse.xml", eng120);
            //var editedCourse = s2.DeserialiseFromFile<Course>($"{_path}/XMLCoursesEdited.xml");


            var s3 = SerialiserFactory.MakeSerialiser("Json");
            s3.SerialiseToFile($"{_path}/JsonTrainee.json", trainee);
            var desJTrainee = s3.DeserialiseFromFile<Trainee>($"{_path}/JsonTrainee.json");

            s3.SerialiseToFile($"{_path}/Course.json", eng120);
            var desJCourse = s3.DeserialiseFromFile<Course>($"{_path}/Course.json");

        }
    }
}