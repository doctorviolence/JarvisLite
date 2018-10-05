import axiosInstance from './axios-instance';

class ApiHomes {

    getHomes = () => {
        return axiosInstance.get('/homes', {
                headers: {'Content-Type': 'application/json'}
            }
        )
    };

    getHomeData = (id) => {
        return axiosInstance.get('/homes/' + id + '/data', {
                headers: {'Content-Type': 'application/json'}
            }
        )
    };
}

const apiHomes = new ApiHomes();
export default apiHomes;
