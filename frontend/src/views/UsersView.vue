<script setup lang="ts">
    import { ref } from 'vue'
    import DataTable from '@/components/DataTable.vue'
    import CommonButton from '@/components/CommonButton.vue'
    import { useGetUsers } from '@/composables/Users/GetUsers'
    import { useGetUserById } from '@/composables/Users/GetUserById'
    import { useCreateUser } from '@/composables/Users/CreateUser'
    import { useUpdateUser } from '@/composables/Users/UpdateUser'
    import { useDeleteUser } from '@/composables/Users/DeleteUser'

    interface Columns {
        key: string
        title: string
    }

    const columns: Columns[] = [
        { key: 'id', title: 'ID' },
        { key: 'name', title: 'Name' },
        { key: 'email', title: 'Email' }
    ]

    class CreateUser{
        constructor(public name: string, public email: string) {}
    }

    class UpdateUser{
        constructor(public id: number, public name: string, public email: string) {}
    }

    const userId = ref(1)
    const name = ref('')
    const email = ref('')

    const { users, getUsers } = useGetUsers()
    const { userById, getUserById } = useGetUserById()
    const { createUserResponse, createUser } = useCreateUser()
    const { updateUserResponse, updateUser } = useUpdateUser()
    const { deleteUserResponse, deleteUser } = useDeleteUser()
    
    const activeView = ref<'allUsers' | 'userById' | 'createUser' | 'updateUser' | 'deleteUser' | null>(null)

    const handleGetUsers = async () => {
        await getUsers()
        activeView.value = 'allUsers'
    }

    const handleGetUserById = async () => {
        await getUserById(userId.value)
        activeView.value = 'userById'
    }

    const handleCreateUser = async () => {
        await createUser(new CreateUser(name.value, email.value))
        activeView.value = 'createUser'
    }

    const handleUpdateUser = async () => {
        await updateUser(new UpdateUser(userId.value, name.value, email.value))
        activeView.value = 'updateUser'
    }

    const handleDeleteUser = async () => {
        await deleteUser(userId.value)
        activeView.value = 'deleteUser'
    }
</script>

<template>
    <div>
        <div>
            <CommonButton :click="handleGetUsers" text="GetAllUsers" />
            <CommonButton :click="handleGetUserById" text="GetUserById" />
            <CommonButton :click="handleCreateUser" text="CreateUser" />
            <CommonButton :click="handleUpdateUser" text="UpdateUser" />
            <CommonButton :click="handleDeleteUser" text="DeleteUser" />
        </div>
        <div>
            <div class="m-2">
                <label for="userId">User ID：</label>
                <input class="border p-2 rounded-md" type="number" v-model="userId" />
            </div>
            <div class="m-2">
                <label for="name">Name：</label>
                <input class="border p-2 rounded-md" type="text" v-model="name" />
            </div>
            <div class="m-2">
                <label for="email">Email：</label>
                <input class="border p-2 rounded-md" type="email" v-model="email" />
            </div>
        </div>
    </div>
    
    <div v-if="activeView === 'allUsers'" class="grid place-items-center">
        <DataTable :columns="columns" :datas="users" />
    </div>
    
    <div v-if="activeView === 'userById'" class="grid place-items-center">
        <DataTable :columns="columns" :datas="[userById]" />
    </div>

    <div v-if="activeView === 'createUser'" class="grid place-items-center">
        <DataTable :columns="columns" :datas="[createUserResponse]" />
    </div>

    <div v-if="activeView === 'updateUser'" class="grid place-items-center">
        <DataTable :columns="columns" :datas="[updateUserResponse]" />
    </div>

    <div v-if="activeView === 'deleteUser'" class="grid place-items-center">
        <p v-if="deleteUserResponse.success">User deleted successfully!</p>
        <p v-else>User deletion failed!</p>
    </div>
</template>