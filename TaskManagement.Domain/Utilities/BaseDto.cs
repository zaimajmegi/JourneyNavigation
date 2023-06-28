using Mapster;

namespace TaskManagement.API.Extensions
{
    public abstract class BaseDto<TDto, TEntity> : IRegister
        where TDto : class, new()
        where TEntity : class, new()
    {
        private TypeAdapterConfig Config { get; set; } = null!;

        public void Register(TypeAdapterConfig config)
        {
            Config = config;
            AddCustomMappings();

            Config.ForType<List<TDto>, List<TEntity>>();
            Config.ForType<List<TEntity>, List<TDto>>();

            Config.ForType<PagedResult<TDto>, PagedResult<TEntity>>();
            Config.ForType<PagedResult<TEntity>, PagedResult<TDto>>();
        }

        public TEntity ToEntity()
        {
            return this.Adapt<TEntity>();
        }

        public TEntity ToEntity(TEntity entity)
        {
            return (this as TDto).Adapt(entity);
        }

        public static TDto FromEntity(TEntity entity)
        {
            return entity.Adapt<TDto>();
        }

        public static List<TDto> FromEntityList(List<TEntity> entities)
        {
            return entities.Adapt<List<TDto>>();
        }

        public static List<TEntity> ToEntityList(List<TDto> dto)
        {
            return dto.Adapt<List<TEntity>>();
        }

        public static List<TEntity> ToEntityList(List<TDto> dto, List<TEntity> entities)
        {
            return dto.Adapt(entities);
        }

        public static PagedResult<TDto> FromEntityPagedResult(PagedResult<TEntity> entities)
        {
            return entities.Adapt<PagedResult<TDto>>();
        }

        public static PagedResult<TEntity> ToEntityPagedResult(PagedResult<TDto> entities)
        {
            return entities.Adapt<PagedResult<TEntity>>();
        }

        public virtual void AddCustomMappings()
        {
        }

        protected TypeAdapterSetter<TDto, TEntity> SetCustomMappings()
        {
            return Config.ForType<TDto, TEntity>();
        }

        protected TypeAdapterSetter<TEntity, TDto> SetCustomMappingsInverse()
        {
            return Config.ForType<TEntity, TDto>();
        }
    }

}
