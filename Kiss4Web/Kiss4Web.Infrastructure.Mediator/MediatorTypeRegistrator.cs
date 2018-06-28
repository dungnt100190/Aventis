using System.Linq;
using Kiss4Web.Infrastructure.Modularity;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.Mediator
{
    public class MediatorTypeRegistrator : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies assemblies)
        {
            container.Register<IMediator, Mediator>();
            var conreteCommandHandler = container.GetTypesToRegister(typeof(TypedMessageHandler<>), assemblies.Assemblies)
                                                 .Where(typ => typ.IsPublic && typ.BaseType?.GetGenericArguments()[0]?.IsDerivedOfType<Message>() == true)
                                                 .ToList();
            //var conreteCommandHandler = assemblies.Assemblies
            //                                      .SelectMany(ass => ass.GetTypes())
            //                                      .Where(typ => typ.BaseType != null &&
            //                                                    typ.BaseType.IsConstructedGenericType &&
            //                                                    typ.BaseType.GetGenericTypeDefinition() == typeof(TypedMessageHandler<>) &&
            //                                                    typ.BaseType.GetGenericArguments()[0].IsDerivedOfType<Message>())
            //                                                    .Select(typ=>new
            //    {
            //        typ
            //    })
            //                                      .ToList();
            conreteCommandHandler.DoForEach(typ => container.RegisterConditional(typ.BaseType, typ, c => !c.Handled));

            var conreteQueryHandler = container.GetTypesToRegister(typeof(TypedMessageHandler<,>), assemblies.Assemblies)
                .Where(typ => typ.IsPublic && typ.BaseType?.GetGenericArguments()[0]?.IsDerivedOfType<Message>() == true)
                .ToList();
            conreteQueryHandler.DoForEach(typ => container.RegisterConditional(typ.BaseType, typ, c => !c.Handled));
        }
    }
}