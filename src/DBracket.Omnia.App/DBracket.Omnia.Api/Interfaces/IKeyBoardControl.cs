namespace DBracket.Omnia.Api.Interfaces
{
    public interface IKeyBoardControl
    {
        #region "--------------------------------- Methods ---------------------------------"
        public void AddShortCut();
        public void DisableShortCut();
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"

        #endregion


        #region "--------------------------------- Events ----------------------------------"

        #endregion

        public enum KeyCode
        {
            WinLeft = 91,
            WindRight = 92,
            Space = 32
        }
    }
}