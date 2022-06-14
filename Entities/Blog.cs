namespace react_api.Entities{
    
    //record types
    //used for immutable objects
    //with-expressions support
    //value-based equality support (able to compare 2 of the same item only matches if all properties match)
    public record Blog{

        public Guid Id {get; init;}
        //only sets the id during the creation of the obj
        public string Name {get; init;}
        public string Description{get; set;}
        public DateTimeOffset CreatedDate {get; init;}
    }
}
