using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataMasterMind_Model
{
    public class RowsDefault
    {
         public static RowElements ROW_BRYW = new RowElements().AddElement(Colors.C_BLA)
                                                               .AddElement(Colors.C_RED)
                                                               .AddElement(Colors.C_YEL)
                                                               .AddElement(Colors.C_WHI);
        
        public static RowElements ROW_YROW = new RowElements().AddElement(Colors.C_YEL)
                                                              .AddElement(Colors.C_RED)
                                                              .AddElement(Colors.C_ORA)
                                                              .AddElement(Colors.C_WHI);

        public static RowElements ROW_RYOW = new RowElements().AddElement(Colors.C_RED)
                                                              .AddElement(Colors.C_YEL)
                                                              .AddElement(Colors.C_ORA)
                                                              .AddElement(Colors.C_WHI);

        public static RowElements ROW_WVOY = new RowElements().AddElement(Colors.C_WHI)
                                                              .AddElement(Colors.C_VIO)
                                                              .AddElement(Colors.C_ORA)
                                                              .AddElement(Colors.C_YEL);

        public static RowElements ROW_GROB = new RowElements().AddElement(Colors.C_GRE)
                                                              .AddElement(Colors.C_RED)
                                                              .AddElement(Colors.C_ORA)
                                                              .AddElement(Colors.C_BLA);

        public static RowElements ROW_YWGO = new RowElements().AddElement(Colors.C_YEL)
                                                              .AddElement(Colors.C_WHI)
                                                              .AddElement(Colors.C_GRE)
                                                              .AddElement(Colors.C_ORA);

        public static RowElements ROW_OGVW = new RowElements().AddElement(Colors.C_ORA)
                                                              .AddElement(Colors.C_GRE)
                                                              .AddElement(Colors.C_VIO)
                                                              .AddElement(Colors.C_WHI);

        public static RowElements ROW_OGVL = new RowElements().AddElement(Colors.C_ORA)
                                                              .AddElement(Colors.C_GRE)
                                                              .AddElement(Colors.C_VIO)
                                                              .AddElement(Colors.C_LIM);
    }
}