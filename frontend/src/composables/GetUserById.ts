import { ref } from 'vue'
import axios from 'axios'

interface UserByIdResponseDto {
    id: number
    name: string
    email: string
}

export const useGetUserById = () => {
    const apiUrl = import.meta.env.VITE_API_URL

    const userById = ref<UserByIdResponseDto>({
        id: 0,
        name: '',
        email: ''
    });

    const getUserById = async (id: number) => {
        const res = await axios.get(`${apiUrl}/users/${id}`)

        userById.value = res.data
    };

    return { userById, getUserById }
}