using UnityEngine;

namespace itismarciiExtansion.Runtime.Extra
{
    public static class MeshTable
    {
        private static int[] s_Table = new int[] { };

        public static void SetupTable(in int amount)
        {
            s_Table = new int[amount];

            if (amount % 4 == 0)
            {
                for (var i = 0; i < amount;)
                {
                    s_Table[i++] = i * i;
                    s_Table[i++] = i * i;
                    s_Table[i++] = i * i;
                    s_Table[i++] = i * i;
                }
                return;
            }
        
            if (amount % 2 == 0)
            {
                for (var i = 0; i < amount;)
                {
                    s_Table[i++] = i * i;
                    s_Table[i++] = i * i;
                }
                return;
            }

            for (var i = 0; i < amount; i++)
            {
                s_Table[i] = i * i;
            }
        }

        public static int GetFraction(in int verticesCount)
        {
            if (s_Table.Length == 0)
            {
                SetupTable(100);
                Debug.LogWarning("Please setup MeshTable before searching for the fraction.");
            }

            if (s_Table.Length % 4 == 0)
            {
                for (var i = 0; i < s_Table.Length;)
                {
                    if (s_Table[i++] == verticesCount) return i;
                    if (s_Table[i++] == verticesCount) return i;                
                    if (s_Table[i++] == verticesCount) return i;
                    if (s_Table[i++] == verticesCount) return i;
                }
            }
        
            if (s_Table.Length % 2 == 0)
            {
                for (var i = 0; i < s_Table.Length;)
                {
                    if (s_Table[i++] == verticesCount) return i;
                    if (s_Table[i++] == verticesCount) return i;
                }
            }
        
            for (var i = 0; i < s_Table.Length; i++)
            {
                if (s_Table[i] == verticesCount) return i;
            }

            Debug.LogError("VerticesCount not inside the table. Make sure its a square number (Example: 4x4)");
            return 0;
        }
    }
}
