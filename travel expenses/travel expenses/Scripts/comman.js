// Convert date to DD-MM-YYYY format
function ConvertJsonDateString(jsonDate) {
    if (!jsonDate) return "-";

    try {
        let date;

        // Case 1: /Date(1717843200000)/
        const match = /\/Date\((\d+)\)\//.exec(jsonDate);
        if (match) {
            date = new Date(parseInt(match[1]));
        } else {
            // Case 2: ISO format (2025-06-09T00:00:00)
            date = new Date(jsonDate);
        }

        if (isNaN(date)) return "-";

        const day = String(date.getDate()).padStart(2, '0');
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const year = date.getFullYear();

        return `${day}-${month}-${year}`;
    } catch (e) {
        console.error("Invalid date format:", jsonDate);
        return "-";
    }
}

// Convert date to YYYY-MM-DD format (useful for input fields)
function ConvertJsonDateStringymd(jsonDate) {
    if (!jsonDate) return "-";

    try {
        let date;

        const match = /\/Date\((\d+)\)\//.exec(jsonDate);
        if (match) {
            date = new Date(parseInt(match[1]));
        } else {
            date = new Date(jsonDate);
        }

        if (isNaN(date)) return "-";

        const day = String(date.getDate()).padStart(2, '0');
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const year = date.getFullYear();

        return `${year}-${month}-${day}`;
    } catch (e) {
        return "-";
    }
}
function ConvertJsonDateForInput(jsonDate) {
    if (!jsonDate) return "";

    let date;

    const match = /\/Date\((\d+)\)\//.exec(jsonDate);
    if (match) {
        date = new Date(parseInt(match[1]));
    } else {
        date = new Date(jsonDate);
    }

    if (isNaN(date)) return "";

    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');

    return `${year}-${month}-${day}T${hours}:${minutes}`;
}

