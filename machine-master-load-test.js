
import http from 'k6/http';
import { check } from 'k6';

const BASE_URL = __ENV.BASE_URL || 'https://localhost:7038';
const TEST_TYPE = __ENV.TEST_TYPE || 'vus';

export const options = {
    insecureSkipTLSVerify: true,

    scenarios: TEST_TYPE === 'rps'
        ? {
            request_test: {
                executor: 'ramping-arrival-rate',
                startRate: 100,
                timeUnit: '1s',
                preAllocatedVUs: 200,
                maxVUs: 1500,
                stages: [
                    { target: 100, duration: '1m' },
                    { target: 500, duration: '1m' },
                    { target: 1000, duration: '1m' },
                ],
            },
        }
        : {
            user_test: {
                executor: 'ramping-vus',
                startVUs: 0,
                stages: [
                    { target: 100, duration: '30s' },
                    { target: 250, duration: '30s' },
                    { target: 500, duration: '30s' },
                    { target: 0, duration: '10s' },
                ],
            },
        },

    thresholds: {
        http_req_failed: ['rate<0.01'],
        http_req_duration: ['p(95)<2000'],
    },
};

export default function () {
    const response = http.get(`${BASE_URL}/api/MachineMaster`);

    check(response, {
        'status is 200': (r) => r.status === 200,
    });
}
