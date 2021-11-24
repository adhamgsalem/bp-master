import { check, sleep } from "k6";
import http from "k6/http";
import { htmlReport } from "https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js";

export function handleSummary(data) {
    return {
        'summary.html': htmlReport(data, { debug: false }),
        stdout: textSummary(data, { indent: ' ', enableColors: true }),
    }
}

export let options = {
    stages: [
        { duration: "1m", target: 20 },           // 1 new vu every 3 seconds
        { duration: "1m", target: 20 },
        { duration: "1m", target: 0 }             // 1 less vu every 3 seconds
    ],
    thresholds: {
        "http_req_duration": ["p(95) < 200"]
    },

    discardResponseBodies: true,

    ext: {
        loadimpact: {
            distribution: {
                loadZoneLabel1: { loadZone: "amazon:ie:dublin", percent: 100 },
            }
        }
    }
};

export default function main() {
    let response = http.get('https://bp-ca1-qa.azurewebsites.net/')
    sleep(1)
}