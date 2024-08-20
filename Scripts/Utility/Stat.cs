    public class Stat<T1, T2>
    {
        public Stat(T1 first, T2 second)
        {
            Value = first;
            Modifier = second;
        }
        public T1 Value { get; set; }
        public T2 Modifier { get; set; }
    }