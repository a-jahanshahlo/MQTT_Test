 
 
    public class ConstsRedisChannel
    {
        public static string HasWarningsQueueChannel { get; set; } = "has_warnings_queue";
        public static string DetectionQueueChannel { get; set; }= "detection_queue";

    }
    public class MQTTConfig
    {
        public static string Address { get;   } = "79.175.157.228";
        public static int Port { get;   } = 1883;
        public static string Username { get;   } = "interview";
        public static string Password { get;   } = "interview123"; 
        public static string Topic { get;   } = "sensor_logs/#";

    }
    public class RedisConfig
    {
        public static string Address { get;   } = "79.175.157.233";
        public static int Port { get;   } = 6379;
        public static string Password { get;   } = "asb31cdnaksord";

    }
 