import { ref } from 'vue'
import axios from 'axios'

interface UsersResponseDto {
    id: number
    name: string
    email: string
}

export const useGetUsers = () => {
    const apiUrl = import.meta.env.VITE_API_URL

    const users = ref<UsersResponseDto[]>([]);

    const getUsers = async () => {
        const res = await axios.get(`${apiUrl}/users`)

        users.value = res.data
    }

    return { users, getUsers }
}
