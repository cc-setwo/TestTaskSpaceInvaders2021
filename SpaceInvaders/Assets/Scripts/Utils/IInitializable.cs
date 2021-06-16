namespace SpaceInvaders.Utils
{
    public interface IInitializable
    {
        bool IsInitialized { get; set; }
        void Initialize();
    }
}