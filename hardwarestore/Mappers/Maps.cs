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
            CreateMap<ProductDetail, ProductDetailsViewModel>().ReverseMap();
          ////  CreateMap<Supplier, CalcationViewModel>().ReverseMap();

            CreateMap<Employee, EmployeeViewModels>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<SalesItem, SalesItemViewModel>().ReverseMap();



        }
    }
}
