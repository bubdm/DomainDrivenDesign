namespace Joska.DomainDrivenDesign.Common.Tests
{
    public class TestDomainEvent : IDomainEvent
    {
        public int Version { get;set;} 
        public string Name { get;set;}

    }
}