using MovieECommerce.Models;
using MovieECommerce.ViewModels;

namespace MovieECommerce.MappingProfiles
{
    public class ActorProfile : AutoMapper.Profile
    {
        public ActorProfile()
        {
            CreateMap<ActorViewModel, Actor>();
            CreateMap<Actor, ActorViewModel>();
        }
    }
}
