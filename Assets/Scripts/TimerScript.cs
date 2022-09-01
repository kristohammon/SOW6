using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerScript : MonoBehaviour
{

    public float timer = 0f; // what goes up with time
    public float calendartimer = 0f; // also goes up with time but resets every month
    public int MasterYear = 2022; // the year
    public float MasterDay = 1; // Day since start of game, only increasing
    public int monthNumber = 0; // index for month list
    public int weekdayNumber = 0; // index for weekday list
    public List<Month> calendar = new List<Month>();
    private float OldCalendarDay = 1; // to know when the calendar day changes
    public List<string> weekdays = new List<string>();

    void Start()
    {
        CreateCalendar();
        CreateWeekdays();
    }

    // Update is called once per frame
    void Update()
    {
        Calendarize();
        DayCounter();
        Weekday();
    }

    void DayCounter()
    {
        timer += Time.deltaTime;
        MasterDay = Mathf.Floor(4 * timer);
    }



    //specifies how long each month is
    void CreateCalendar()
    {
        calendar.Add(new Month("January", 31));
        calendar.Add(new Month("February", 28));
        calendar.Add(new Month("March", 31));
        calendar.Add(new Month("April", 30));
        calendar.Add(new Month("May", 31));
        calendar.Add(new Month("June", 30));
        calendar.Add(new Month("July", 31));
        calendar.Add(new Month("August", 31));
        calendar.Add(new Month("September", 30));
        calendar.Add(new Month("October", 31));
        calendar.Add(new Month("November", 30));
        calendar.Add(new Month("December", 31));

    }

    //runs the calendar
    void Calendarize()
    {
        calendartimer += Time.deltaTime;
        float CalendarDay = Mathf.Floor(4 * calendartimer); // 4 days every second
        if (CalendarDay > calendar[monthNumber].days)
        {
            calendartimer -= (calendar[monthNumber].days / 4f);
            CalendarDay = Mathf.Floor(4 * calendartimer);
            if (monthNumber == 11)
            {
                monthNumber = 0;
                MasterYear += 1;
            }
            else
            {
                monthNumber += 1;
            }          
        }
        

        if (OldCalendarDay != CalendarDay)
        {
            //Debug.Log(weekdays[weekdayNumber] + " " + calendar[monthNumber].name + " " + CalendarDay + ", " + MasterYear);
            //Debug.Log(MasterDay);
        }
        OldCalendarDay = CalendarDay;
    }

    // specifies the names and order of the weekdays
    void CreateWeekdays()
    {
        weekdays.Add("Saturday"); // pos 0
        weekdays.Add("Sunday"); 
        weekdays.Add("Monday");
        weekdays.Add("Tuesday");
        weekdays.Add("Wednesday");
        weekdays.Add("Thursday");
        weekdays.Add("Friday");
    }

    //determines what weekday it is
    void Weekday()
    {
        weekdayNumber = (int)MasterDay % 7;
    }
}


public class Month : IComparable<Month>
{
    public string name;
    public int days;

    public Month(string newName, int newDays)
    {
        name = newName;
        days = newDays;
    }

    //This method is required by the IComparable
    //interface. 
    public int CompareTo(Month other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in power.
        return days - other.days;
    }
}