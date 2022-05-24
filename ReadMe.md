# IPM Decisions Works - Resource Search Service

Web API in charge of returning H2020 IPM Decisions DSS information from the plaform

## End points available

The API has autogerated documentation using `swagger` and it is accessible on the following URL `/api/sch/swagger/index.html`, but the following is short summary of the endpoints available.

### Search all the resources

- Method type: **POST**

- The endpoint URL is:

  > `THEHOSTURL`/api/search

- The required headers are:

  | Key          | Value            |
  | ------------ | ---------------- |
  | Content-Type | application/json |

- The payload is the following:

  ```json
  {
    "regions": ["string"],
    "pests": ["string"],
    "crops": ["string"],
    "language": "string"
  }
  ```

  - The `pests` and `crops` properties are expecting [EPPO codes](https://www.eppo.int/RESOURCES/eppo_databases/eppo_codes).

  - The `language` property is expecting the value following the [ISO 639-1 Code](https://www.loc.gov/standards/iso639-2/php/code_list.php) standards.

  - The `regions` property is expecting the value following the [Country Codes Alpha-3](https://www.iban.com/country-codes) standards.

- The return object will be a **json** object with the following structure:

  ```json
  [
    {
      "idResource": "string",
      "resourceName": "string",
      "regions": ["string"],
      "languages": ["string"],
      "resourceType": "string",
      "project": "string"
    }
  ]
  ```

- Limitations:

  When doing the **POST** method, the property `language` only accepts one language, as, if available, will return the text translated on the language selected. If not translations available, the data will be returned using the default language.

### Get detailed information of a resource

- Method type: **GET**

- The endpoint URL is:

  > `THEHOSTURL`/api/search/**{idResource}**

- The return object will be a **json** object with the following structure:

```json
{
  "resourceId": "string",
  "resourceOrigin": "string",
  "resourceName": "string",
  "description": "string",
  "resourceType": "string",
  "contactInstitution": "string",
  "contactEmail": "string",
  "contactPhone": "string",
  "contactAddress": "string",
  "links": "string",
  "project": "string",
  "citation": "string",
  "pests": ["string"],
  "crops": ["string"],
  "regions": ["string"],
  "languages": ["string"]
}
```

- Limitations:

When doing the **GET** method, no `language` is specified, so the data will be returned using the default language.

## Examples for the _Search all the resources endpoint_

1. No filters on **POST** call.

   Request Payload

   ```json
   {}
   ```

   Returned information.

   > STATUS: `200 OK`

   ```json
   [
       {
           "idResource": "dk.seges;SEPTORIAHU",
           "resourceName": "Septoria Humidity Model",
           "regions": [
               "NOR",
               "DNK"
           ],
           "languages": [
               "Danish",
               "English"
           ],
           "resourceType": "IPM Decisions Model",
           "project": "IPM Decisions"
       },
       {
           "idResource": "dk.seges;CPO",
           "resourceName": "CPO model",
           "regions": [
               "NOR",
               "DNK",
               "SWE",
               "FIN",
               "EST",
               "LVA",
               "LTU",
               "POL",
               "DEU",
               "NLD",
               "BEL",
               "GBR",
               "IRL"
           ],
           "languages": [
               "Danish",
               "English"
           ],
           "resourceType": "IPM Decisions Model",
           "project": "IPM Decisions"
       },
       //////
       ///
       SOME DATA HAS BEEN OMITTED FOR READABILITY PURPOSES.
       ///
       //////
       {
           "idResource": "com.ipmwise;ipmwise.demo",
           "resourceName": "IPMwise demo version",
           "regions": [
               "DNK"
           ],
           "languages": [
               "English",
               "Danish",
               "Norwegian",
               "Spanish"
           ],
           "resourceType": "IPM Decisions Model",
           "project": "IPM Decisions"
       },
       {
           "idResource": "gr.gaiasense.ipm;PLASVI",
           "resourceName": "Downy mildew of grapevine",
           "regions": [
               "GRC"
           ],
           "languages": [
               "Greek",
               "English"
           ],
           "resourceType": "IPM Decisions Model",
           "project": "IPM Decisions"
       }
   ]
   ```

1. `Crops` filter on **POST** call.

   Request Payload

   ```json
   {
     "crops": ["DAUCS", "HORVW", "SOLTU"]
   }
   ```

   Returned information.

   > STATUS: `200 OK`

   ```json
   [
     {
       "idResource": "no.nibio.vips;PSILARTEMP",
       "resourceName": "Carrot rust fly temperature model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "no.nibio.vips;PSILAROBSE",
       "resourceName": "Carrot rust fly observation model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "no.nibio.vips;NAERSTADMO",
       "resourceName": "Nærstad model",
       "regions": ["NOR", "SWE"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "no.nibio.vips;ALTERNARIA",
       "resourceName": "Alternaria TOMCAST",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "no.nibio.vips;NEGPROGMOD",
       "resourceName": "Negative prognosis",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "adas.dss;DASGPA",
       "resourceName": "Cutworm Model",
       "regions": ["GBR"],
       "languages": ["English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "adas.dss;RHOPPA",
       "resourceName": "BYDV TSUM model",
       "regions": ["GBR"],
       "languages": ["English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "adas.dss;PHYTIN",
       "resourceName": "Hutton Criteria Late Blight Model",
       "regions": ["GBR"],
       "languages": ["English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     }
   ]
   ```

1. `Pests` filter on **POST** call.

   Request Payload

   ```json
   {
     "pests": ["PSILRO", "DASGPA"]
   }
   ```

   Returned information.

   > STATUS: `200 OK`

   ```json
   [
     {
       "idResource": "no.nibio.vips;PSILARTEMP",
       "resourceName": "Carrot rust fly temperature model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "no.nibio.vips;PSILAROBSE",
       "resourceName": "Carrot rust fly observation model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "adas.dss;DASGPA",
       "resourceName": "Cutworm Model",
       "regions": ["GBR"],
       "languages": ["English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     }
   ]
   ```

1. `Crops` and `Pests` filter on **POST** call.

   Request Payload

   ```json
   {
     "pests": ["PSILRO", "DASGPA"],
     "crops": ["DAUCS", "HORVW", "SOLTU"]
   }
   ```

   Returned information.

   > STATUS: `200 OK`

   ```json
   [
     {
       "idResource": "no.nibio.vips;PSILARTEMP",
       "resourceName": "Carrot rust fly temperature model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "no.nibio.vips;PSILAROBSE",
       "resourceName": "Carrot rust fly observation model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "adas.dss;DASGPA",
       "resourceName": "Cutworm Model",
       "regions": ["GBR"],
       "languages": ["English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     }
   ]
   ```

1. `Crops`, `Pests` and `Regions` filter on **POST** call.

   Request Payload

   ```json
   {
     "pests": ["PSILRO", "DASGPA"],
     "crops": ["DAUCS", "HORVW", "SOLTU"],
     "regions": ["NOR"]
   }
   ```

   Returned information.

   > STATUS: `200 OK`

   ```json
   [
     {
       "idResource": "no.nibio.vips;PSILARTEMP",
       "resourceName": "Carrot rust fly temperature model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "no.nibio.vips;PSILAROBSE",
       "resourceName": "Carrot rust fly observation model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     }
   ]
   ```

1. `Crops`, `Pests`, `Regions` and an **existing** `language` filter on **POST** call.

   Request Payload

   ```json
   {
     "pests": ["PSILRO", "DASGPA"],
     "crops": ["DAUCS", "HORVW", "SOLTU"],
     "regions": ["NOR"],
     "language": "no"
   }
   ```

   Returned information.

   > STATUS: `200 OK`

   ```json
   [
     {
       "idResource": "no.nibio.vips;PSILARTEMP",
       "resourceName": "Gulrotflue svermetidspunktmodell",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "no.nibio.vips;PSILAROBSE",
       "resourceName": "Carrot rust fly observation model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     }
   ]
   ```

1. `Crops`, `Pests`, `Regions` and a NOT **existing** `language` filter on **POST** call.

   Request Payload

   ```json
   {
     "pests": ["PSILRO", "DASGPA"],
     "crops": ["DAUCS", "HORVW", "SOLTU"],
     "regions": ["NOR"],
     "language": "es"
   }
   ```

   Returned information.

   > STATUS: `200 OK`

   ```json
   [
     {
       "idResource": "no.nibio.vips;PSILARTEMP",
       "resourceName": "Carrot rust fly temperature model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     },
     {
       "idResource": "no.nibio.vips;PSILAROBSE",
       "resourceName": "Carrot rust fly observation model",
       "regions": ["NOR"],
       "languages": ["Norwegian", "English"],
       "resourceType": "IPM Decisions Model",
       "project": "IPM Decisions"
     }
   ]
   ```

1. Filter combination do NOT **exist** on **POST** call.

   Request Payload

   ```json
   {
     "pests": ["DASGPA"],
     "crops": ["HORVW"]
   }
   ```

   Returned information.

   > STATUS: `200 OK`

   ```json
   []
   ```

## Examples for the _Get detailed information of a resource_

1. Existing ID on service
   Request URL

   > `THEHOSTURL`/api/search/dk.seges;SEPTORIAHU

   Returned information.

   > STATUS: `200 OK`

   ```json
   {
     "resourceId": "dk.seges;SEPTORIAHU",
     "resourceOrigin": "https://www.vips-landbruk.no/forecasts/models/SEPTORIAHU/",
     "resourceName": "Septoria Humidity Model",
     "description": "THE PEST: Leaf blotch diseases of wheat can be caused by septoria tritici blotch (Zymoseptoria tritici) and staganospora nodorum blotch (Parastagonospora nodorum), which are both  favoured by wet conditions. \nTHE DECISION: Fungicide treatments may need to be applied between stem extension and ear emergence, mainly to protect the upper leaves.  \nTHE MODEL: The humidity model estimates risk of septoria tritici blotch infections in winter wheat. Risk of attack is assumed after 20 hours with continuous wetness. A wet hour is defined as minimum 0,2 mm precipitation in an hour or minimum 85% relative humidity. \nTHE PARAMETERS: Weather data from GS 31 are used. In addition, the dates of occurrence of growth stages 31 and 32 are entered. The model calculates the expected date for the other stages. This can be adjusted manually. Adding information on fungicide spraying dates is vital for the model. After spraying, the model assumes that the crop is protected for 10 days. The thresholds for number of wet hours and relative humidity can be adjusted manually.  \nSOURCE: Created by Aahus University and SEGES and released in Denmark in 2017. Tested in Lithuania, Norway, Sweden, Finland and Denmark in 2018 and 2019. \nASSUMPTIONS: septoria tritici blotch is present and periods with high humidity create risk for a damaging epidemic",
     "resourceType": "IPM Decisions Model",
     "contactInstitution": "SEGES",
     "contactEmail": "info@seges.dk",
     "contactPhone": null,
     "contactAddress": "Agro Food Park 15, Aarhus N, Denmark, 8200",
     "links": null,
     "project": "IPM Decisions",
     "citation": "",
     "pests": ["SEPTTR", "LEPTNO", "PYRNTR"],
     "crops": ["3WHEC"],
     "regions": ["NOR", "DNK"],
     "languages": ["Danish", "English"]
   }
   ```

1. Non existing ID on service
   Request URL

   > `THEHOSTURL`/api/search/NotExisting;SEPTORIAHU

   Returned information.

   > STATUS: `404 Not Found`

   ```json
   {
     "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
     "title": "Not Found",
     "status": 404,
     "traceId": "00-7e62e690be52bd4a8bd31127c82f394a-0656ffe4351c694b-00"
   }
   ```

1. ID do not follow default convention

   Request URL

   > `THEHOSTURL`/api/search/dk.seges

   Returned information.

   > STATUS: `400 Bad Request`

   ```json
   {
     "message": "The ID should hold the DSS Id and the model Id, e.g: 'adas.dss;CARPPO'"
   }
   ```
