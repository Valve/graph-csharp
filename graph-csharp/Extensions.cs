using System;


namespace graph_csharp {
    public static class Extensions {
        public static void Times(this int i, Action<int> action) {
            for (int j = 0; j < i; j++) {
                action(j);
            }
        }
        public static void Times(this int i, Action action) {
            for (int j = 0; j < i; j++) {
                action();
            }
        }
    }
}
