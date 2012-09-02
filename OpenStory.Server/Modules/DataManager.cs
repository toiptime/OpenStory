using OpenStory.Server.Data.Providers;

namespace OpenStory.Server.Modules
{
    /// <summary>
    /// Provides methods and components for managing server data.
    /// </summary>
    public class DataManager : ManagerBase<DataManager>
    {
        /// <summary>
        /// Gets the ban data provider.
        /// </summary>
        public IBanDataProvider Bans { get; private set; }

        /// <summary>
        /// Gets the account data provider.
        /// </summary>
        public IAccountDataProvider Accounts { get; private set; }

        /// <summary>
        /// Initializes a new instance of <see cref="DataManager"/>.
        /// </summary>
        public DataManager()
        {
            base.RequireComponent("Bans", typeof(IBanDataProvider));
            base.RequireComponent("Accounts", typeof(IAccountDataProvider));
        }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.Bans = base.GetComponent<IBanDataProvider>("Bans");
            this.Accounts = base.GetComponent<IAccountDataProvider>("Accounts");
        }
    }
}