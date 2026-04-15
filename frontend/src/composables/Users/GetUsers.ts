import { ref } from 'vue'
import axios from 'axios'
import { apiUrl } from '../ApiUrl'

interface UsersResponseDto {
    id: number
    name: string
    email: string
}

export const useGetUsers = () => {
    const users = ref<UsersResponseDto[]>([]);

    const getUsers = async () => {
        const res = await axios.get(`${apiUrl}/users`)
            .then(res => {
                users.value = res.data
                return users.value
            })
            .catch(err => {
                return []
            })

        users.value = res ?? []
    }

    return { users, getUsers }
}
