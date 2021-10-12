using Alex.Business.Core.Notifications;
using Alex.Business.Models.Fornecedores;
using Alex.Business.Models.Fornecedores.Services;
using Alex.Business.Models.Produtos;
using Alex.Business.Models.Produtos.Services;
using Alex.Infra.Data.Context;
using Alex.Infra.Data.Repository;
using AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace Alex.AppMVC.App_Start {
    public class DependencyInjectionConfig {
        public static void RegisterDIContainer() {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            InitializeContainer(container);

            // Registra todos os controllers
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            #region SetResolver
                // Adiciona o SimpleInjector como auxiliar na criação das instâncias no MVC
                // no momento da criação dos Controllers (Etapa de ControllerFactory), 
                // fornecendo as instâncias necessárias
            #endregion
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container) {
            #region LyfeStyle Singleton
            // Uma única instância por aplicação.
            // Não deve ser utilizado para objetos que realizam operações no Bando de Dados
            #endregion
            #region LyfeStyle Transient
            // Cria uma nova instância para cada injeção de dependência.
            #endregion
            #region LyfeStyle Scoped
            // Só existe em contextos WEB
            // Cria uma nova instância por Request
            // Ideal para aplicações WEB
            #endregion

            container.Register<AppDBContext>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<INotifier, Notifier>(Lifestyle.Scoped);
            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));
        }
    }
}