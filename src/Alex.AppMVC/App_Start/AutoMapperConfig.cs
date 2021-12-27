using Alex.AppMVC.ViewModels;
using Alex.Business.Models.Fornecedores;
using Alex.Business.Models.Produtos;
using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Alex.AppMVC.App_Start {
    public class AutoMapperConfig {
        public static MapperConfiguration GetMapperConfiguration() {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg => {
                foreach(var profile in profiles) {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    public class AutoMapper : Profile {
        public AutoMapper() {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
        }
    }
}