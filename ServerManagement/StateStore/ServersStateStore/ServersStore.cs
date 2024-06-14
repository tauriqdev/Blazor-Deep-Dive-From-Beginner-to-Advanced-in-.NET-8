namespace ServerManagement.StateStore.ServersStateStore
{
    public abstract class ServersStore : Observer
    {
        private int _numberServersOnline;

        public int GetNumberServersOnline() => _numberServersOnline;

        public void SetNumberServersOnline(int number)
        {
            _numberServersOnline = number;
            BroadcastStateChange();
        }
    }
}
