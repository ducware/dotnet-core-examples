# Automated API tests using Postman CLI

🔗 **API Endpoint**: [https://dateapiv1.azurewebsites.net/v1/times/specific-month?Month=0&Year=](https://dateapiv1.azurewebsites.net/v1/times/specific-month?Month=12&Year=22)0

### ✨ Test case example

```jsx
pm.test("Status code is 200 when success", function () {
    if (pm.response.json().code === 'success') {
        pm.response.to.have.status(200);
    }
});
```

```jsx
pm.test("Status code is not 200 when error", function () {
    if (pm.response.json().code === 'error') {
        pm.expect(pm.response.code).to.not.eql(200);
    }
});
```

```jsx
pm.test("Number of dates returned is correct", function () {
    const responseJson = pm.response.json();
    if (responseJson.code === 'success') {
        pm.expect(responseJson.data.dates.length).to.eql(31);
    }
});
```

```jsx
pm.test("Error message exists when error", function () {
    const responseJson = pm.response.json();
    if (responseJson.code === 'error') {
        pm.expect(responseJson).to.have.property('message');
    }
});
```

```jsx
pm.test("DateTime is unrepresentable when error", function () {
    const responseJson = pm.response.json();
    if (responseJson.code === 'error') {
        pm.expect(responseJson.message).to.include('un-representable DateTime');
    }
});
```

```jsx
pm.test("Success response must have data property", function () {
    const responseJson = pm.response.json();
    if (responseJson.code === 'success') {
        pm.expect(responseJson).to.have.property('data');
    }
});
```

```jsx
pm.test("Erorr response to have message property", function () {
    const responseJson = pm.response.json();
    if (responseJson.code === 'error') {
        pm.expect(responseJson).to.have.property('message');
    }
});
```

```jsx
pm.test("dates format", function () {
    const responseJson = pm.response.json();

    if (responseJson.code === 'success') {
        for (let i = 0; i < 5; i++) {
            pm.expect(responseJson.data.dates[i].ddMMyyyy).to.match(/^(0[1-9]|1[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/\d{4}$/);
        }
    }
});
```

```jsx
pm.test("Schema is valid", function () {
    const successSchema = {
        type: 'object',
        properties: {
            code: {
                type: 'string'
            },
            data: {
                type: 'object',
                items: {
                    properties: {
                        dates: {
                            type: 'array',
                        }
                    },
                }
            },
        },
        required: ['code', 'data']
    }

    const errorSchema = {
        type: 'object',
        properties: {
            code: {
                type: 'string'
            },
            message: {
                type: 'string'
            },
        },
        required: ['code', 'message']
    }

    const responseJson = pm.response.json();
    if (responseJson.code === 'success') {
        pm.response.to.have.jsonSchema(successSchema);
    }
    else {
        pm.response.to.have.jsonSchema(errorSchema);
    }
});
```

**🧪 Test results:**

![Untitled](Automated%20API%20tests%20using%20Postman%20CLI%20ca81d5a0caab4c69ac4bc239deb32765/Untitled.png)

## Configure command  to run collection on CI/CD pineline

![Untitled](Automated%20API%20tests%20using%20Postman%20CLI%20ca81d5a0caab4c69ac4bc239deb32765/Untitled%201.png)

![Untitled](Automated%20API%20tests%20using%20Postman%20CLI%20ca81d5a0caab4c69ac4bc239deb32765/Untitled%202.png)

![Untitled](Automated%20API%20tests%20using%20Postman%20CLI%20ca81d5a0caab4c69ac4bc239deb32765/Untitled%203.png)

<!--
Reference: https://youtu.be/zp5Jh2FIpF0?si=MLdMJsKEImnmlAYN
-->
