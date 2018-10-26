using System;

/// <summary>
/// Эта структура предназначена для хранения информации о времени, позваляет сравнивать времена (раньше или позже) и искать разность. Работает в диапазоне от дней до наносекунд. Также позваляет хранить комментарий о событии, для которого это время записано.<para>Приятная плюшка.</para>
/// Вы можете применять математические операции + и - (+= и -=) и операции сравнения (== и !=, &lt; и &gt;, &lt;= и &gt;=)
/// </summary>
public struct DateNanos
{
    /// <summary>
    /// Дни
    /// </summary>
    public short Days;
    /// <summary>
    /// Часы
    /// </summary>
    public short Hours;
    /// <summary>
    /// Минуты
    /// </summary>
    public short Minutes;
    /// <summary>
    /// Секунды
    /// </summary>
    public short Seconds;
    /// <summary>
    /// Миллисекунды
    /// </summary>
    public short Millis;
    /// <summary>
    /// Микросекунды
    /// </summary>
    public short Micros;
    /// <summary>
    /// Наносекунды
    /// </summary>
    public short Nanos;
    /// <summary>
  
  
    /// <summary>
    /// Этот конструктор принемает на вход числовые параметры времени от дня до наносекунды
    /// </summary>
    /// <param name="Day">День</param>
    /// <param name="Hou">Час</param>
    /// <param name="Min">Минута</param>
    /// <param name="Sec">Секунда</param>
    /// <param name="Mil">Миллисекунда</param>
    /// <param name="Mic">Микросекунда</param>
    /// <param name="Nan">Наносекунда</param>
    public DateNanos(short Day, short Hou, short Min, short Sec, short Mil, short Mic, short Nan)
    {
        Days = Day;
        Hours = Hou;
        Minutes = Min;
        Seconds = Sec;
        Millis = Mil;
        Micros = Mic;
        Nanos = Nan;
        makeCorrect();
    }

    /// <summary>
    /// Этот конструктор принемает на вход строку в формате формате "DD.HH.MM.SS.mSmSmSmS.mcSmcSmcS.nSnSnSnS"
    /// </summary>
    /// <param name="Time">Строка с временем</param>
    public DateNanos(string Time)
    {
        string[] tmp = Time.Split('.');
        short[] tmp2 = new short[tmp.Length];
        for (int i = 0; i < tmp.Length; i++)
        {
            tmp2[i] = Convert.ToInt16(tmp[i]);
        }

        Days = tmp2[0];
        Hours = tmp2[1];
        Minutes = tmp2[2];
        Seconds = tmp2[3];
        Millis = tmp2[4];
        Micros = tmp2[5];
        Nanos = tmp2[6];
        makeCorrect();
    }

    /// <summary>
    /// Этот метод прибовляет к времени данного экземпляра время-аргумент и приводит результат к правельному виду.
    /// </summary>
    /// <param name="date">Время, на которое нужно увеличить это время</param>
    void add(DateNanos date)
    {
        this.Days += date.Days;
        this.Hours += date.Hours;
        this.Minutes += date.Minutes;
        this.Seconds += date.Seconds;
        this.Millis += date.Millis;
        this.Micros += date.Micros;
        this.Nanos += date.Nanos;
        makeCorrect();
    }

    /// <summary>
    /// Этот метод прибовляет к текущему времени заданное количество миллисекунд и приводит данное время к правельному виду.
    /// </summary>
    /// <param name="nanos">Количество миллисекунд, на которое нужно увеличить это время</param>
    public void add(ulong nanos)
    {
        DateNanos b = new DateNanos();
        b.setNanos(nanos);
        add(b);
    }

    /// <summary>
    /// Этот метод вычитает из данного экземпляра времени время аргумент и приводит результат к правельному виду.
    /// ВАЖНО!!! ОТРИЦАТЕЛЬНОЕ ВРЕМЯ НЕПРЕДСКАЗУЕМО СЕБЯ ВЕДЕТ. НЕ СОВЕТУЮ ВЫЧИТАТЬ ИЗ МЕНЬШЕГО ВРЕМЕНИ БОЛЬШЕЕ
    /// </summary>
    /// <param name="date">На сколько времени нужно уменьшить это время</param>
    void subtract(DateNanos date)
    {
        makeCorrect();
        date.makeCorrect();
        if (compare(date) >= 0)
        {
            this.Days -= date.Days;
            this.Hours -= date.Hours;
            this.Minutes -= date.Minutes;
            this.Seconds -= date.Seconds;
            this.Millis -= date.Millis;
            this.Micros -= date.Micros;
            this.Nanos -= date.Nanos;
        }
        else
        {
            this.Days = (short)(date.Days - this.Days);
            this.Hours = (short)(date.Hours - this.Hours);
            this.Minutes = (short)(date.Minutes - this.Minutes);
            this.Seconds = (short)(date.Seconds - this.Seconds);
            this.Millis = (short)(date.Millis - this.Millis);
            this.Micros = (short)(date.Micros - this.Micros);
            this.Nanos = (short)(date.Nanos - this.Nanos);
        }
        makeCorrect();
    }

    /// <summary>
    /// Этот метод вычитает из текущего времени заданное количество миллисекунд и приводит данное время к правельному виду.
    /// ВАЖНО!!! ОТРИЦАТЕЛЬНОЕ ВРЕМЯ НЕПРЕДСКАЗУЕМО СЕБЯ ВЕДЕТ. НЕ СОВЕТУЮ ВЫЧИТАТЬ ИЗ МЕНЬШЕГО ВРЕМЕНИ БОЛЬШЕЕ
    /// </summary>
    /// <param name="nanos">Количество миллисекунд, на которое нужно уменьшить это время</param>
    public void subtract(ulong nanos)
    {
        DateNanos b = new DateNanos();
        b.setNanos(nanos);
        subtract(b);
    }

    /// <summary>
    /// Приводит время к правильному виду (Если миллисекунд было более 1000, то +1 секунда и -1000 миллисекунд и т.д.)
    /// </summary>
    public void makeCorrect()
    {
        while (Nanos >= 1000)
        {
            Nanos -= 1000;
            Micros++;
        }
        while (Micros >= 1000)
        {
            Micros -= 1000;
            Millis++;
        }
        while (Millis >= 1000)
        {
            Millis -= 1000;
            Seconds++;
        }
        while (Seconds >= 60)
        {
            Seconds -= 60;
            Minutes++;
        }
        while (Minutes >= 60)
        {
            Minutes -= 60;
            Hours++;
        } while (Hours >= 24)
        {
            Hours -= 24;
            Days++;
        }



        while (Nanos < 0)
        {
            Nanos += 1000;
            Micros--;
        }
        while (Micros < 0)
        {
            Micros += 1000;
            Millis--;
        }
        while (Millis < 0)
        {
            Millis += 1000;
            Seconds--;
        }
        while (Seconds < 0)
        {
            Seconds += 60;
            Minutes--;
        }
        while (Minutes < 0)
        {
            Minutes += 60;
            Hours--;
        } while (Hours < 0)
        {
            Hours += 24;
            Days--;
        }


    }

    /// <summary>
    /// Этот метод возвращает время полность переведенное в наносекунды.
    /// Да-да, даже дни конвертируються :)
    /// ВАЖНО!!! ЧТОБЫ ПОЛУЧИТЬ АДЕКВАТНОЕ ЧИСЛО С УЧЁТОМ ВСЕ СВОДИТЬСЯ К ulong!!!
    /// НЕ ИСПОЛЬЗУЙТЕ ОТРИЦАТЕЛЬНОЕ ВРЕМЯ!!!
    /// </summary>
    /// <returns>Время в наносекундах</returns>
    public ulong getNanos()
    {
        ulong m = (ulong)((Days * 864000000000) + (Hours * 3600000000000) + (Minutes * 60000000000) + (Seconds * 1000000000) + (Millis * 1000000) + (Micros * 1000) + Nanos);
        return m;
    }

    /// <summary>
    /// Вы можете указать количество наносекунд в качестве аргумента функции,
    /// функция приведет их к стандартному виду и запишет это время в данный экземпляр
    /// </summary>
    /// <param name="nanos"></param>
    public void setNanos(ulong nanos)
    {
        Nanos = (short)(nanos % 1000);
        ulong tmp = nanos / 1000;
        Micros = (short)(tmp % 1000); tmp /= 1000;
        Millis = (short)(tmp % 1000); tmp /= 1000;
        Seconds = (short)(tmp % 60); tmp /= 60;
        Minutes = (short)(tmp % 60); tmp /= 60;
        Hours = (short)(tmp % 24); Days = (short)(tmp / 24);
        makeCorrect();
    }

    /// <summary>
    /// Этот метод сравнивает время данного экземпляра и параметра
    /// </summary>
    /// <param name="date"> 
    /// Возвращает -1, если параметр больше;
    ///             0, если равны;
    ///             1, если экземпляр больше параметра;</param>
    /// <returns>Результат сравнения</returns>
    short compare(DateNanos date)
    {
        if (Days > date.Days) { return 1; } else if (Days < date.Days) { return -1; }

        if (Hours > date.Hours) { return 1; } else if (Hours < date.Hours) { return -1; }
        if (Minutes > date.Minutes) { return 1; } else if (Minutes < date.Minutes) { return -1; }
        if (Seconds > date.Seconds) { return 1; } else if (Seconds < date.Seconds) { return -1; }
        if (Millis > date.Millis) { return 1; } else if (Millis < date.Millis) { return -1; }
        if (Micros > date.Micros) { return 1; } else if (Micros < date.Micros) { return -1; }
        if (Nanos > date.Nanos) { return 1; } else if (Nanos < date.Nanos) { return -1; }

        return 0;
    }

    /// <summary>
    /// Возвращает разницу между временем данного экземпляра и аргумента, выраженную в наносекундах.
    /// <para>
    /// при слишком большом значении памяти ulong может не хватить!!!</para>
    /// </summary>
    /// <param name="b">То, с чем сравнивать</param>
    /// <returns>Разница, в наносекундах</returns>
    public ulong difference(DateNanos b)
    {
        DateNanos a = this;
        if (a.compare(b) > 0)
        {
            a.subtract(b);
            return a.getNanos();
        }
        else if (a.compare(b) < 0)
        {
            b.subtract(a);
            return b.getNanos();

        }
        else { return 0; }

    }

    /// <summary>
    /// Возвращает разницу между временем данного экземпляра и аргумента, выраженную в наносекундах.<para>
    /// при слишком большом значении памяти ulong может не хватить!!!</para>
    /// </summary>
    /// <param name="a">То, что сравнивать</param>
    /// <param name="b">То, с чем сравнивать</param>
    /// <returns>Разница, в наносекундах</returns>
    static public ulong difference(DateNanos a, DateNanos b)
    {
        if (a.compare(b) > 0)
        {
            a.subtract(b);
            return a.getNanos();
        }
        else if (a.compare(b) < 0)
        {
            b.subtract(a);
            return b.getNanos();

        }
        else { return 0; }

    }

    /// <summary>
    /// Превращает строчку в формате "DD.HH.MM.SS.mSmSmSmS.mcSmcSmcS.nSnSnSnS" в DateNanos
    /// Например, строчка "24.13.55.14.503.63.110" будет записана в DataNanos как
    /// 24 день 13 часов 55 минут 14 секунд 503 миллисекунд 63 микросекунд 110 наносекунд  
    /// </summary>
    /// <param name="str">Строка со временем в формате "DD.HH.MM.SS.mSmSmSmS.mcSmcSmcS.nSnSnSnS"</param>
    /// <returns>структура DataNanos</returns>
    public static DateNanos ParseStringToDate(string str)
    {
        string[] tmp = str.Split('.');
        short[] tmp2 = new short[tmp.Length];
        for (int i = 0; i < tmp.Length; i++)
        {
            tmp2[i] = Convert.ToInt16(tmp[1]);
        }
        return new DateNanos(tmp2[0], tmp2[1], tmp2[2], tmp2[3], tmp2[4], tmp2[5], tmp2[6]);
    }
    public static DateNanos operator +(DateNanos op1, DateNanos op2)
    {
        op1.add(op2);
        return op1;
    }
    public static DateNanos operator ++(DateNanos op)
    {
        op.Millis++;
        op.makeCorrect();
        return op;
    }
    public static DateNanos operator --(DateNanos op)
    {
        op.Millis--;
        op.makeCorrect();
        return op;
    }
    public static DateNanos operator -(DateNanos op1, DateNanos op2)
    {
        op1.subtract(op2);
        return op1;
    }
    public static bool operator ==(DateNanos op1, DateNanos op2)
    {
        if (op1.compare(op2) == 0) { return true; }
        return false;
    }
    public static bool operator !=(DateNanos op1, DateNanos op2)
    {
        if (op1.compare(op2) == 0) { return false; }
        return true;
    }
    public static bool operator >(DateNanos op1, DateNanos op2)
    {
        if (op1.compare(op2) > 0) { return true; }
        return false;
    }
    public static bool operator <(DateNanos op1, DateNanos op2)
    {
        if (op1.compare(op2) < 0) { return true; }
        return false;
    }

    public static bool operator >=(DateNanos op1, DateNanos op2)
    {
        if (op1.compare(op2) >= 0) { return true; }
        return false;
    }
    public static bool operator <=(DateNanos op1, DateNanos op2)
    {
        if (op1.compare(op2) <= 0) { return true; }
        return false;
    }
    /// <summary>
    /// Эта функция определяет, являеться ли данное время и время в аргументе одним и тем же событием с учетом погрешности измерения prem в наносекундах
    /// </summary>
    /// <param name="b">С чем сравнить данный экземпляр</param>
    /// <param name="prem">Погрешность измерения (в наносекундах)</param>
    /// <returns>True, если |a-b|&lt;=c. False, если нет.</returns>
    public bool isEventSimul(DateNanos b, int prem)
    {
        DateNanos a = this;
        DateNanos c = new DateNanos(0, 0, 0, 0, 0, 0, (short)prem);
        c.makeCorrect();
        a.makeCorrect();
        b.makeCorrect();
        short comp = a.compare(b);
        if (comp == 0) { return true; }
        else if (comp == -1)
        {
            if ((b - a) <= c) { return true; }
        }
        else if (comp == 1) { if ((a - b) <= c) { return true; } }

        return false;
    }
    /// <summary>
    /// Эта функция определяет, являеться ли времена a и b одними и теми же событиями с учетом погрешности измерения prem в наносекундах
    /// </summary>
    /// <param name="a">Что сравниваем</param>
    /// <param name="b">С чем сраваем</param>
    /// <param name="prem">Погрешность измерения (в наносекундах)</param>
    /// <returns>True, если |a-b|&lt;=c. False, если нет.</returns>
    public static bool is_A_EventSimulB(DateNanos a, DateNanos b, int prem)
    {
        DateNanos c = new DateNanos(0, 0, 0, 0, 0, 0, (short)prem);
        c.makeCorrect();
        a.makeCorrect();
        b.makeCorrect();
        short comp = a.compare(b);
        if (comp == 0) { return true; }
        else if (comp == -1)
        {
            if ((b - a) <= c) { return true; }
        }
        else if (comp == 1) { if ((a - b) <= c) { return true; } }

        return false;
    }
    public static bool isEventSimul(string a, string b, int prem)
    {
        return is_A_EventSimulB(new DateNanos(a), new DateNanos(b), prem);
    }
}

