namespace Kntaco.AlcNetAcademy.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 先輩の間違いの種類を表します。
    /// </summary>
    public class SeniorSelectionText : Dictionary<long, string>
    {
        /// <summary>
        /// <see cref="SeniorSelectionText"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        public SeniorSelectionText()
        {
            this.Add(1, "スペル");
            this.Add(2, "単数複数");
            this.Add(3, "冠詞(a,an,the)");
            this.Add(4, "時制(過去,現在,未来)");
            this.Add(5, "３単現(動詞原形+s,es)");
            this.Add(6, "語句の選び方");
            this.Add(7, "語句の過不足");
            this.Add(8, "語句の順序/構文");
        }
    }
}
