using System;

namespace Joska.DomainDrivenDesign.Common
{
    public abstract class GuidEntity : Entity<Guid, Identity<Guid>>
    {

    }
}