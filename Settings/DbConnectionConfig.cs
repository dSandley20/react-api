using System;
namespace react_api.Entities
{
    //TODO move to a seperate folder where configs will live
    public record DbConnectionConfig
    {
        public string HostIP { get; init; }
        public string HostPort { get; init; }
        public string DatabaseName { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }
        public string AuthMethod { get; init; }

        public string ConnectionString {
            get{
                return $"mongodb://{UserName}:{Password}@{HostIP}:{HostPort}/?{AuthMethod}";
            }
        }
    }
}
