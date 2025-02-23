using DBracket.Omnia.Api.Interaces;

namespace DBracket.Omnia.Api
{
    public sealed class OmniaCore
    {
        #region "----------------------------- Private Fields ------------------------------"
        private static OmniaCore _instance = new OmniaCore();
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        private OmniaCore()
        {

        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public static OmniaCore GetInstance()
        {
            return _instance;
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public IKeyBoardControl KeyBoardControl { get; private set; }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}