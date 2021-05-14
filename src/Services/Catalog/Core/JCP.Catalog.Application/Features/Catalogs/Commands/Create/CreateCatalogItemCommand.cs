using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCP.Catalog.Application.Features.Catalogs.Commands.Create
{
    public partial class CreateCatalogItemCommand : IRequest<CreateCatalogItemResponse>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int BrandId { get; set; }
    }
}
