
package reciclaUAGenReciclaUARESTAzure.uiModels.utils;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.TimeZone;
import java.util.Calendar;

/**
 * Created by Javier Galvan Martinez and powered by OOH4RIA on 14/01/2016.
 *
 * Code autogenerated. Do not modify this file.
 */

/**
 * Created by Javier Galvan Martinez and powered by OOH4RIA on 03/03/2016.
 */
public class DateUtils {

    private static String stringFormat = "yyyy-MM-dd'T'HH:mm:ss";

    public static String dateToFormatString(Date date)
    {
        String stringDate = "";
        if(date != null)
        {
            DateFormat df = new SimpleDateFormat(stringFormat);
            stringDate = df.format(date);
        }
        return stringDate;
    }
    public static String dateToFormatString(Date date, SimpleDateFormat dateFormat)
    {
        String stringDate = "";
        if(date != null)
        {
            stringDate = dateFormat.format(date);
        }
        return stringDate;
    }
    public static Date stringToDateFormat(String stringDate)
    {
        Date date = new Date();
        if(stringDate != null && !stringDate.equals(""))
        {
            String stringWithoutMills = stringDate.substring(0,19);
            SimpleDateFormat isoFormat = new SimpleDateFormat(stringFormat);
            isoFormat.setTimeZone(TimeZone.getTimeZone("UTC"));
            try {
                date = isoFormat.parse(stringWithoutMills);
            } catch (ParseException e) {
                e.printStackTrace();
            }
        }
        return date;
    }

    public static String dateToSendRESTFormatString(Date date)
    {
        String stringDate = "";
        if(date != null)
        {
            Calendar calendar = Calendar.getInstance();
            calendar.setTime(date);
            stringDate += calendar.get(Calendar.DAY_OF_MONTH);
            stringDate += "%2F" + (calendar.get(Calendar.MONTH) + 1);
            stringDate += "%2F" + calendar.get(Calendar.YEAR);
        }
        return stringDate;
    }
}

