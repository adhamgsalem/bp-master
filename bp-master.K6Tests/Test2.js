// Creator: k6 Browser Recorder 0.6.2

import { sleep, group } from "k6";
import http from "k6/http";
import { htmlReport } from "https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js";

export function handleSummary(data) {
    return {
        'summary.html': htmlReport(data, { debug: false }),
        stdout: textSummary(data, { indent: ' ', enableColors: true }),
    }
}

export const options = { vus: 10, duration: "5m" };

export default function main() {
    let response;

    const vars = {};

    group("page_1 - https://bp-ca1-qa.azurewebsites.net/", function () {
        response = http.get("https://bp-ca1-qa.azurewebsites.net/", {
            headers: {
                "upgrade-insecure-requests": "1",
                "sec-ch-ua":
                    '"Google Chrome";v="95", "Chromium";v="95", ";Not A Brand";v="99"',
                "sec-ch-ua-mobile": "?0",
                "sec-ch-ua-platform": '"Windows"',
            },
        });

        vars["__RequestVerificationToken"] = response
            .html()
            .find("input[name=__RequestVerificationToken]")
            .first()
            .attr("value");

        sleep(14.5);

        response = http.post(
            "https://bp-ca1-qa.azurewebsites.net/",
            {
                "BP.Systolic": "90",
                "BP.Diastolic": "50",
                __RequestVerificationToken: `${vars["__RequestVerificationToken"]}`,
            },
            {
                headers: {
                    "content-type": "application/x-www-form-urlencoded",
                    origin: "https://bp-ca1-qa.azurewebsites.net/",
                    "upgrade-insecure-requests": "1",
                    "sec-ch-ua":
                        '"Google Chrome";v="95", "Chromium";v="95", ";Not A Brand";v="99"',
                    "sec-ch-ua-mobile": "?0",
                    "sec-ch-ua-platform": '"Windows"',
                },
            }
        );
        sleep(3.8);
    });

    group(
        "page_2 - https://bp-ca1-qa.azurewebsites.net/HeartRate",
        function () {
            response = http.get(
                "https://bp-ca1-qa.azurewebsites.net/HeartRate",
                {
                    headers: {
                        "upgrade-insecure-requests": "1",
                        "sec-ch-ua":
                            '"Google Chrome";v="95", "Chromium";v="95", ";Not A Brand";v="99"',
                        "sec-ch-ua-mobile": "?0",
                        "sec-ch-ua-platform": '"Windows"',
                    },
                }
            );
            sleep(4.2);

            response = http.post(
                "https://bp-ca1-qa.azurewebsites.net//HeartRate",
                {
                    "HR.HeartRate": "90",
                    __RequestVerificationToken:
                        "CfDJ8LLparmLRbtNgd2IETgxRsDpc7vJ7Dzuq6EQebTYKYYOi43eybH77adNekbTH8lD4ED7Dj8eQLB_pNk8BmD2VIb3w2HjDFof7R1_F3kK67KThavpUAYITI7Hd8PF6bXcunEThIYlzRMM21GzKD3i9kk",
                },
                {
                    headers: {
                        "content-type": "application/x-www-form-urlencoded",
                        origin: "https://bp-ca1-qa.azurewebsites.net/",
                        "upgrade-insecure-requests": "1",
                        "sec-ch-ua":
                            '"Google Chrome";v="95", "Chromium";v="95", ";Not A Brand";v="99"',
                        "sec-ch-ua-mobile": "?0",
                        "sec-ch-ua-platform": '"Windows"',
                    },
                }
            );
        }
    );
}