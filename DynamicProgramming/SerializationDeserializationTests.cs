using Newtonsoft.Json;

namespace DynamicProgramming
{
    public class SerializationDeserializationTests
    {
        public static void RunTests()
        {
            SerializationDeserializationTests tests = new SerializationDeserializationTests();
            tests.DeserializeTest();
        }

        public void DeserializeTest()
        {
            const string json = "{'FirstName': 'Sarah','LastName': 'Smith'}";

            dynamic? customer = JsonConvert.DeserializeObject(json);
            Console.WriteLine($"Customer name is {customer?.FirstName} {customer?.LastName}");
        }
    }


}
