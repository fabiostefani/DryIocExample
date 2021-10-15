using DryIoc;
using DryIoCExample.Repository;

namespace DryIoCExample.Infra
{
    public static class DryIocConfig
    {
        public static void Register(IRegistrator r)
        {
            r.Register<IOrderRepository, OrderRepository>();
            r.Register<IUserRepository, UserRepository>();
        }
    }
}