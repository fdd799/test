import { ref } from 'vue'
import axios from 'axios'
import { apiUrl } from '../ApiUrl'

interface CreateUserResponseDto {
    name: string
    email: string
}

export const useCreateUser = () => {
    const createUserResponse = ref<CreateUserResponseDto>({
        name: '',
        email: ''
    })

    const createUser = async (user: CreateUserResponseDto) => {
        const res = await axios.post(`${apiUrl}/users`, user)
            .then(res => {
                createUserResponse.value = res.data
                return createUserResponse.value
            })
            .catch(err => {
                alert(err.response.data.message)
                return {
                    name: '',
                    email: ''
                }
            })

        createUserResponse.value = res
    }

    return { createUserResponse, createUser }
}