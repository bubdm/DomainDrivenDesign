using System.Collections.Generic;

namespace Joska.DomainDrivenDesign.Common.Tests
{
    public class TestValueObject : ValueObject
    {
        public int A { get; }
        public int B { get; }
        public string C { get; }

        public TestValueObject(int a, int b, string c)
        {
            A = a;
            B = b;
            C = c;
        }

        protected override IEnumerable<object> GetAttributes()
        {
            yield return A;
            yield return B;
            yield return C;
        }
    }
}