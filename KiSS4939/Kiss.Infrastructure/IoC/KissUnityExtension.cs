using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;

namespace Kiss.Infrastructure.IoC
{
    internal class KissUnityExtension : UnityContainerExtension
    {
        #region EventHandlers

        private void Context_Registering(object sender, RegisterEventArgs e)
        {
            if (e.TypeFrom != null)
            {
                if (e.TypeFrom.IsGenericTypeDefinition && e.TypeTo.IsGenericTypeDefinition)
                {
                    Context.Policies.Set<IBuildKeyMappingPolicy>(
                        new GenericTypeBuildKeyMappingPolicy(new NamedTypeBuildKey(e.TypeTo, e.Name)),
                        new NamedTypeBuildKey(e.TypeFrom, e.Name));
                }
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// This is the main extension method.
        /// </summary>
        protected override void Initialize()
        {
            Context.Registering += Context_Registering;

            // register custom policies
            Context.Policies.Set<IConstructorSelectorPolicy>(new ConstructorSelectorPolicy(), null);
        }

        #endregion

        #endregion
    }
}