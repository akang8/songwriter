import axios from 'axios'

// Add a response interceptor
axios.interceptors.response.use(function (response) {
    // Do something with response data
    return response;
}, function (error) {

    // Do something with response error
    if (error.response) {
        // The request was made and the server responded with a status code
        // that falls out of the range of 2xx
        console.log("Log error.response");
        console.log(error.response.data);
        console.log(error.response.status);
        console.log(error.response.headers);
    } else if (error.request) {
        // The request was made but no response was received
        // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
        // http.ClientRequest in node.js
        console.log("Log error.request");
        console.log(error.request);
    } else {
        // Something happened in setting up the request that triggered an Error
        console.log("Log error.message");
        console.log('Error', error.message);
    }

    return Promise.reject(error);
});

export default axios;
