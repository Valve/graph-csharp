using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graph_csharp {
    public class DFSPaths {
        private bool[] _marked;
        private int[] _edgeTo;
        private readonly int _s;

        public DFSPaths(Graph g, int s) {
            _marked = new bool[g.V];
            _edgeTo = new int[g.V];
            _s = s;
            dfs(g, s);
        }

        private void dfs(Graph g, int v) {
            _marked[v] = true;
            foreach (var adj in g.Adjacent(v)) {
                if (!_marked[adj]) {
                    _edgeTo[adj] = v;
                    dfs(g, adj);
                }
            }
        }

        public bool HasPathTo(int v) {
            return _marked[v];
        }

        public IEnumerable<int> PathTo(int v) {
            if (!HasPathTo(v)) return null;
            var path = new Stack<int>();
            for (int x = v; x != _s; x = _edgeTo[x]) {
                path.Push(x);

            }
            path.Push(_s);
            return path;
        }
    }
}
