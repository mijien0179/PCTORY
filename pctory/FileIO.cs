using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pctory
{
    static internal class FileIO
    {
        /// <summary>
        /// <c>filepath</c>에 파일을 열어 스트림으로 반환합니다.
        /// </summary>
        /// <param name="filepath">열 파일</param>
        /// <returns>filepath에 대한 스트림 데이터. 실패시 null</returns>
        public static StreamWriter OpenFile(string filepath) {
            
            return null;
        }

        /// <summary>
        /// 스트림 플러시
        /// </summary>
        /// <param name="stream">플러시 할 스트림</param>
        public static void Flush(StreamWriter stream)
        {
            stream.Flush();
        }

        /// <summary>
        /// <c>stream</c>에 데이터를 씁니다.
        /// </summary>
        /// <param name="stream">쓰기에 사용할 스트림</param>
        /// <param name="obj">입력할 데이터</param>
        /// <returns></returns>
        public static StreamWriter Write(StreamWriter stream, Object obj)
        {
            // 여기에 작성

            return stream;
        }

        /// <summary>
        /// 데이터를 스트림에서 읽어옵니다.
        /// </summary>
        /// <param name="reader">데이터를 읽어 올 스트림</param>
        /// <returns>스트림에서 읽어 온 <c>ProcessInfoList</c></returns>
        public static ProcessInfoList ReadFile(StreamReader reader)
        {
            // 여기에 작성
            return null;
        }
    }
}
