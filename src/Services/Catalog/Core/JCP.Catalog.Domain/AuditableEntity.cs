using System;

namespace JCP.Catalog.Domain
{
    // TODO: Move to common project to be used from all projects
    public abstract class AuditableEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
