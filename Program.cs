
namespace CreditandStoreage
{
    class StoreageCard
    {
        public string user;
        private int money;
        public int Money
        {
            get { return money; }
            set { money = value; }
        }
    }
    class Credit_Card : StoreageCard
    {
        private int time;
        Deposit_card card1;
        public Credit_Card(string u, int t, int m, Deposit_card c)
        {
            user = u; time = t; Money = m; card1 = c;
        }
        public int Time
        {
            get { return time; }
            set { time = value; }
        }
        public void paymoney()
        {
            Console.WriteLine("用户{0}:信用卡待还:{1}，储蓄卡余额:{2}", user, Money, card1.Money);
            if (card1.Money < Money)
            {
                Money -= card1.Money;
                card1.Money = 0;
                Console.WriteLine("已到还款日期,您的储蓄卡余额不足，还完部分欠款后，信用卡待还:{0}，储蓄卡余额:{1}", Money, card1.Money);
            }
            else
            {
                card1.Money -= Money;
                Money = 0;
                Console.WriteLine("已到还款日期,还完欠款后，信用卡待还:{0}，储蓄卡余额:{1}", Money, card1.Money);
            }
        }
        public void notime()
        {
            Console.WriteLine("未到还款日期，储蓄卡余额:{0}，信用卡待还:{1}", Money, card1.Money);
        }

    }
    class Deposit_card : StoreageCard { }
    class Paydelegate
    {
        public delegate void paydelegate();
        public event paydelegate payevent;
        public void Notify()
        {
            if (payevent != null)
            {
                payevent();
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            int paytime = 8;//将还款日期定为每月8号
            Deposit_card D1 = new Deposit_card();
            D1.Money = 1000;
            Credit_Card C1 = new Credit_Card("张三", 8, 3000, D1);
            Paydelegate pay = new Paydelegate();
            if (paytime == C1.Time)
            {
                pay.payevent += new Paydelegate.paydelegate(C1.paymoney);
            }
            else
                pay.payevent += new Paydelegate.paydelegate(C1.notime);
            pay.Notify();
        }

    }
}