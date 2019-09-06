//const csv = require('csvtojson');

const csvFilePath='datafile.csv';


let csvToJson = require('convert-csv-to-json');
 
let json = csvToJson.getJsonFromCsv(csvFilePath);

let jsonArray


console.log(json);