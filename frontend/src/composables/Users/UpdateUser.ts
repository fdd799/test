import { ref } from 'vue'
import axios from 'axios'
import { apiUrl } from '../ApiUrl'

interface UpdateUserResponseDto {
    id: number
    name: string
    email: string
}

export const useUpdateUser = () => {
    const updateUserResponse = ref<UpdateUserResponseDto>({
        id: 0,
        name: '',
        email: ''
    })

    const updateUser = async (user: UpdateUserResponseDto) => {
        const res = await axios.put(`${apiUrl}/users/${user.id}`, user)
            .then(res => {
                updateUserResponse.value = res.data
                return updateUserResponse.value
            })
            .catch(err => {
                alert(err.response.data.message)
                return {
                    id: 0,
                    name: '',
                    email: ''
                }
            })

        updateUserResponse.value = res
    }

    return { updateUserResponse, updateUser }
}