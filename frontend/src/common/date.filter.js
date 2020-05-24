import format from 'date-fns/format'
import parseISO from 'date-fns/parseISO'
import isToday from 'date-fns/isToday'
import isTomorrow from 'date-fns/isTomorrow'

export default (date, includeTime = false) => {
  const parsedDate = parseISO(date)
  const customFormat = includeTime ? 'MMMM dd,yyyy HH:mm' : 'MMMM dd,yyyy'
  if (isToday(parsedDate)) {
    return `Today ${format(parsedDate, customFormat)}`
  } else if (isTomorrow(parsedDate)) {
    return `Tomorrow ${format(parsedDate, customFormat)}`
  }
  return format(parsedDate, `iiii ${customFormat}`)
}
