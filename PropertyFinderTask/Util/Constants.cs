

namespace PropertyFinderTask.Util
{
    public static class Constants
    {
        // In real-life app, consts should be stored in a config-based storage (e.g. AWS Systems Manager Parameter Store)
        public const string MOCK_SERVER = "MockServer";
        public const string HTML_EXTENSION = ".html";
        public const string JSON_EXTENSION = ".json";
        public const string EMPTY_PAYLOAD = "Empty Payload";
        public const string EMPTY_CONTENT = "File has no content";
        public const string GENERIC_ERROR = "Something Went Wrong";
        public const string FILE_NOT_FOUND = "The file does not exist.";
        public const string INCORRECT_CONTENT = "File is Empty/Incorrect";
        public const string INVALID_URL = "Empty URL or Incorrect";
        public const string UNSUPPORTED_TYPE = "File Type Unsupported";
    }
}
