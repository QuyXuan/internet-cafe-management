using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class TimerBLL
    {
        private static TimerBLL instance;
        public static TimerBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TimerBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private TimerBLL() { }

        //Hàm tính thời gian của người chơi tại loại máy đang chơi
        public float ChangeTime(float TotalTime, string NameType)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return 0;
                }
                var MayThuong = context.TypeComputers.FirstOrDefault(p => p.NameType == "Máy Thường");
                var MayHienTai = context.TypeComputers.FirstOrDefault(p => p.NameType == NameType);
                float time = (float)(TotalTime * (MayThuong.Price / MayHienTai.Price));
                return time;
            }
        }

        //Hàm tính thời gian của người chơi về lại máy thường
        public float ChangeTimeToMayThuong(float TotalTime, string NameType)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return 0;
                }
                var MayThuong = context.TypeComputers.FirstOrDefault(p => p.NameType == "Máy Thường");
                var MayHienTai = context.TypeComputers.FirstOrDefault(p => p.NameType == NameType);
                return (float)(TotalTime * (MayHienTai.Price / MayThuong.Price));
            }
        }

        //Hàm quy đổi tiền ra thời gian
        public float ChangeMoneyToTime(double Money, string NameType)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return 0;
                }
                //Money = Money / 1000;
                var MayHienTai = context.TypeComputers.FirstOrDefault(p => p.NameType == NameType);
                float Time = (float)(Money / MayHienTai.Price) * 60;
                return Time;
            }
        }

        //Hàm chuyển từ phút sang giờ, phút
        public Time TranferTime(float toataltime)
        {
            Time time = new Time();
            time.hour = (int)(toataltime / 60);
            time.minute = (int)(toataltime - time.hour * 60);
            time.second = (int)((toataltime - time.hour * 60 - time.minute) * 60);
            return time;
        }

        //Hàm chuyển giờ,phút sang totalTime
        public float TranferTotalTime(Time time)
        {
            float totaltime = 0;
            totaltime += time.hour * 60;
            totaltime += time.minute;
            totaltime += (float)time.second / 60;
            return totaltime;
        }

        //Hàm tính thời gian
        public Time timertick(int hours, int minutes, int seconds)
        {
            Time time = new Time(hours,minutes,seconds);
            if (time.second < 1)
            {
                time.second = 59;
                if (time.minute == 0)
                {
                    time.minute = 59;
                    if (time.hour != 0)
                        time.hour -= 1;
                }
                else
                {
                    time.minute -= 1;
                }
            }
            else
               time.second -= 1;
            return time;
        }

        //Hàm cộng thời gian
        public Time SumTime(float CurrentTime, float UpdateTime)
        {
            float ToatalTime = CurrentTime + UpdateTime;
            return TranferTime(ToatalTime);
        }
        
    }
}
