using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using hardwarestore.Data;
using hardwarestore.Models;

namespace hardwarestore.Mappers
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<ProductHistory, ProductHistoryViewModel>().ReverseMap();
            CreateMap<ProductDetails, ProductDetailsViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();

            CreateMap<Employee, EmployeeViewModels>().ReverseMap();



        }
    }
}
