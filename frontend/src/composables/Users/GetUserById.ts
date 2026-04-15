import { ref } from 'vue'
import axios from 'axios'
import { apiUrl } from '../ApiUrl'

interface UserByIdResponseDto {
    id: number
    name: string
    email: string
}

export const useGetUserById = () => {
    const userById = ref<UserByIdResponseDto>({
        id: 0,
        name: '',
        email: ''
    });

    const getUserById = async (id: number) => {
        const res = await axios.get(`${apiUrl}/users/${id}`)
            .then(res => {
                userById.value = res.data
                return userById.value
            })
            .catch(err => {
                alert(err.response.data.message)
                return {
                    id: 0,
                    name: '',
                    email: ''
                }
            });

        userById.value = res
    };

    return { userById, getUserById }
}